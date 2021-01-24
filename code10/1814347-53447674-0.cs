        public string convertToBinString(String gona)
        {
            byte[] gonaArray = System.Text.Encoding.UTF8.GetBytes(gona);
            return Convert.ToBase64String(gonaArray);
        }
