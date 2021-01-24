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
            female.name = "Lilly";
            male.name = "Shadow";
            male.Marry(female);
            //  female.Marry(male);
            Console.WriteLine(male.ToString());
            Console.WriteLine(female.ToString());
            Console.ReadLine();
        }
    }
