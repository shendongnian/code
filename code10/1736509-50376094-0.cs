    public static string GetObfuscatedValue(string Input)
            {
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Input);
                bytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(bytes);
                string output = Convert.ToBase64String(bytes);
                return output;
            }
