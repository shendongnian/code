    namespace DieRoller
    {
        public class Die
        {
            public int die_faces = 6;
            public int face_value = 1;
    
            public Die(int faces)
            {
                die_faces = faces;
                RollDie();
                GetFaceValue();
                GetNumFaces();
            }
    
            public void RollDie()
            {
                Random rand = new Random();
                face_value = rand.Next(die_faces);
            }
    
            public void GetFaceValue()
            {
                Console.WriteLine("current value of face: {0}", face_value);
            }
    
            public void GetNumFaces()
            {
                Console.WriteLine("current number of faces: {0}", die_faces);
            }
        }
    
        public class Program
        {
            public static void Main()
            {
                 Die myDie = new Die(7);
                 Console.WriteLine();
            }
        }
    }
