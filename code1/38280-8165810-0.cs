        /// <summary>
        /// Calculates the lenght in bytes of an object 
        /// and returns the size 
        /// </summary>
        /// <param name="TestObject"></param>
        /// <returns></returns>
        private int GetObjectSize(object TestObject)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            byte[] Array;
            bf.Serialize(ms, TestObject);
            Array = ms.ToArray();
            return Array.Length;
        }
