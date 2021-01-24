            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(new char[] { '|' });
                if (parts[0] == Users.user)
                {
                    lines[i] = lines[i].Remove(lines[i].Length - 5);
                    lines[i] = lines[i] + "12345";
                }
               
            }
            File.WriteAllText(dirConta, string.Join("\n",lines));
