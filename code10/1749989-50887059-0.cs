    if (openFileDialogOdaberiSliku.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            var bytes = File.ReadAllBytes(openFileDialogOdaberiSliku.FileName);
            uiInputSlika.Text = destinationRead.ToString();
            destinationSave = "..\\bin\\Slike\\Slika" + name;
            File.WriteAllBytes(destinationSave,bytes)
        }
