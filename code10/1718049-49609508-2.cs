    public class Panda
    {
        public string name;
        public Panda Mate;
        public void Marry(Panda partner)
        {
            Mate = partner;
            partner.Mate = this;
        }
        public override string ToString()
        {
            return this.name + " = " + Mate.name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Panda female = new Panda { };
            Panda male = new Panda { };
            female.name = nameof(female);
            male.name = nameof(male);
            male.Marry(female);
            Console.WriteLine(male.ToString());
            Console.WriteLine(female.ToString());
            Console.ReadLine();
        }
    }
