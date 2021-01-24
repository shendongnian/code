    public class Die
    {
        private System.Random rand;
        private int faceValue, numFaces;
        public int GetFaceValue()
        {
            return faceValue;
        }
        public int GetNumFaces()
        {
            return numFaces;
        }
        public void Roll()
        {
            faceValue = rand.Next(1, numFaces + 1);
        }
        public Die()
        {
            rand = new System.Random();
            faceValue = 1;
            numFaces = 6;
        }
        public Die(int faces) : this()
        {
            if (faces >= 3)
            {
                numFaces = faces;
                this.Roll();
            }
        }
    }
    public static class Program
    {
        public static void Main()
        {
            Die d1 = new Die(10);
            Die d2 = new Die(2);
            System.Console.WriteLine("D1: {0} faces; value: {1}",
                                     d1.GetNumFaces(),
                                     d1.GetFaceValue());
            System.Console.WriteLine("D2: {0} faces; value: {1}",
                                     d2.GetNumFaces(),
                                     d2.GetFaceValue());
        }
    }
