    using ga_vector = List<ga_struct>;
    class ga_struct
    {
        public ga_struct(string str, uint fitness)
        {
            Str = str;
            Fitness = fitness;
        }
        public string Str { get; set; }
        public uint Fitness { get; set; }
    }
    class Program
    {
        
        private const int GA_POPSIZE = 2048;
        private const int GA_MAXITER = 16384;
        private const float GA_ELITRATE = 0.10f;
        private const float GA_MUTATIONRATE = 0.25f;
        private const float GA_MUTATION = 32767 * GA_MUTATIONRATE;
        private const string GA_TARGET = "Hello world!";
        private static readonly Random random = new Random((int)DateTime.Now.Ticks);
        static void Main(string[] args)
        {
            ga_vector popAlpha = new ga_vector();
            ga_vector popBeta = new ga_vector();
            InitPopulation(ref popAlpha, ref popBeta);
            ga_vector population = popAlpha;
            ga_vector buffer = popBeta;
            for (int i = 0; i < GA_MAXITER; i++)
            {
                CalcFitness(ref population);
                SortByFitness(ref population);
                PrintBest(ref population);
                if (population[0].Fitness == 0) break;
                Mate(ref population, ref buffer);
                Swap(ref population, ref buffer);
            }
            Console.ReadKey();
        }
        static void Swap(ref ga_vector population, ref ga_vector buffer)
        {
            var temp = population;
            population = buffer;
            buffer = temp;
        }
        static void InitPopulation(ref ga_vector population, ref ga_vector buffer)
        {
            int tsize = GA_TARGET.Length;
            for (int i = 0; i < GA_POPSIZE; i++)
            {
                var citizen = new ga_struct(string.Empty, 0);
                
                for (int j = 0; j < tsize; j++)
                {
                    citizen.Str += Convert.ToChar(random.Next(90) + 32);
                }
                population.Add(citizen);
                buffer.Add(new ga_struct(string.Empty, 0));
            }
        }
        static void CalcFitness(ref ga_vector population)
        {
            const string target = GA_TARGET;
            int tsize = target.Length;
            for (int i = 0; i < GA_POPSIZE; i++)
            {
                uint fitness = 0;
                for (int j = 0; j < tsize; j++)
                {
                    fitness += (uint) Math.Abs(population[i].Str[j] - target[j]);
                }
                population[i].Fitness = fitness;
            }
        }
        static int FitnessSort(ga_struct x, ga_struct y)
        {
            return x.Fitness.CompareTo(y.Fitness);
        }
        static void SortByFitness(ref ga_vector population)
        {
            population.Sort((x, y) => FitnessSort(x, y));
        }
        static void Elitism(ref ga_vector population, ref ga_vector buffer, int esize)
        {
            for (int i = 0; i < esize; i++)
            {
                buffer[i].Str = population[i].Str;
                buffer[i].Fitness = population[i].Fitness;
            }
        }
        static void Mutate(ref ga_struct member)
        {
            int tsize = GA_TARGET.Length;
            int ipos = random.Next(tsize);
            int delta = random.Next(90) + 32;
            var mutated = member.Str.ToCharArray();
            Convert.ToChar((member.Str[ipos] + delta)%123).ToString().CopyTo(0, mutated, ipos, 1);
            member.Str = mutated.ToString();
        }
        static void Mate(ref ga_vector population, ref ga_vector buffer)
        {
            const int esize = (int) (GA_POPSIZE*GA_ELITRATE);
            int tsize = GA_TARGET.Length, spos, i1, i2;
            Elitism(ref population, ref buffer, esize);
            for (int i = esize; i < GA_POPSIZE; i++)
            {
                i1 = random.Next(GA_POPSIZE/2);
                i2 = random.Next(GA_POPSIZE/2);
                spos = random.Next(tsize);
                buffer[i].Str = population[i1].Str.Substring(0, spos) + population[i2].Str.Substring(spos, tsize - spos);
                if (random.Next() < GA_MUTATION)
                {
                    var mutated = buffer[i];
                    Mutate(ref mutated);
                    buffer[i] = mutated;
                }
            }
        }
        static void PrintBest(ref ga_vector gav)
        {
            Console.WriteLine("Best: " + gav[0].Str + " (" + gav[0].Fitness + ")");
        }
