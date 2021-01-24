        using System.Security.Cryptography; 
        //...
        private string GenerateUniqueString(string input )
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(input));
                var res = Convert.ToBase64String(hash);
                return res.Substring(0, res.Length - 2);    
            }
        }
