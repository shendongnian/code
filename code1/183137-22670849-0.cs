    private void EditFile(string path, string oldText, string newText)
            {
                string content = File.ReadAllText(path);
                content = contenido.Replace(oldText, newText);
                File.WriteAllText(path, content);
            }
