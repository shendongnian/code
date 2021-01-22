                RevisionNumber = strRevisionNumber.Substring(strRevisionNumber.LastIndexOf(".") + 1, (strRevisionNumber.LastIndexOf("\"")-1) - strRevisionNumber.LastIndexOf("."));
                String replaceWithText = String.Format("[assembly: AssemblyVersion(\"{0}.{1}.{2}.{3}\")]", MajVersion, MinVersion, BuildNumber, RevisionNumber);
                string newText = Regex.Replace(contents, @"\[assembly: AssemblyVersion\("".*""\)\]", replaceWithText);
                StreamWriter writer = new StreamWriter(FilePath, false);
                writer.Write(newText);
                writer.Close();
            }
            else
            {
                Console.WriteLine("No matching values found");
            }
            }
    }
}
