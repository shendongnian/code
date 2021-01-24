    static void Main(string[] args)
        {
            Process.Start(GenerateURL(0, 0, "-26.235859", "28.077619", 500, 500, 90));
            Console.ReadLine();
        }
        public static string GenerateURL(double heading, double pitch, string locationLat, string locationLong, int resX, int resY, int fov)
        {
            return Sign("https://maps.googleapis.com/maps/api/streetview?size=" + resX + "x" + resY + "&location=" + locationLat + "," + locationLong + "&heading=" + heading + "&pitch=" + pitch + "&fov=" + fov + "&key=" + apiKey, signingKey);
        }
        public static string Sign(string url, string keyString)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            // converting key to bytes will throw an exception, need to replace '-' and '_' characters first.
            string usablePrivateKey = keyString.Replace("-", "+").Replace("_", "/");
            byte[] privateKeyBytes = Convert.FromBase64String(usablePrivateKey);
            Uri uri = new Uri(url);
            byte[] encodedPathAndQueryBytes = encoding.GetBytes(uri.LocalPath + uri.Query);
            // compute the hash
            HMACSHA1 algorithm = new HMACSHA1(privateKeyBytes);
            byte[] hash = algorithm.ComputeHash(encodedPathAndQueryBytes);
            // convert the bytes to string and make url-safe by replacing '+' and '/' characters
            string signature = Convert.ToBase64String(hash).Replace("+", "-").Replace("/", "_");
            // Add the signature to the existing URI.
            return uri.Scheme + "://" + uri.Host + uri.LocalPath + uri.Query + "&signature=" + signature;
        }
