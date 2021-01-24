                        foreach (var file in d2.GetFiles("*.txt"))
                    {
                        Console.WriteLine(file.FullName, file.Name);
                        string temppfad = file.FullName;
                        byte[] Inhaltsbyte = File.ReadAllBytes(temppfad);
                        string Entschlüsselterinhalt = Entschlüsseln(Password, Inhaltsbyte);
                        File.WriteAllText(temppfad, Entschlüsselterinhalt);
                    }
