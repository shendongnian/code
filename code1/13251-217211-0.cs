    [Serializable]
    public struct Vector3
    {
        public double x, y, z;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Vector3 vector = new Vector3();
            vector.x = 1;
            vector.y = 2;
            vector.z = 3;
    
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, vector);
            string str = System.Convert.ToBase64String(memoryStream.ToArray());
    
            //Store str into the database
        }
    }
