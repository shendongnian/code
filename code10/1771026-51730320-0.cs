    private void FormFotos_Load(object sender, EventArgs e)
    {
        // se pretendermos pesquisar em várias pastas
        List<string> diretorios = new List<string>()
        {@"\\server01\folder1\folder2\folder3"};
        // se pretendermos pesquisar as várias extensões
        List<string> extensoes = new List<string>()
        {".jpg",".bmp",".png",".tiff",".gif"};
        DataTable table = new DataTable();
        table.Columns.Add("Nome do ficheiro");
        table.Columns.Add("->Duplo clique-<");
        table.Columns.Add("fullpath");
        foreach (string diretorio in diretorios)
        {
            var ficheiros = Directory.EnumerateFiles(diretorio, "*", SearchOption.AllDirectories).
                Where(r => extensoes.Contains(Path.GetExtension(r.ToLower())));
            foreach (var ficheiro in ficheiros)
            {
                DataRow row = table.NewRow();
                row[0] = Path.GetFileName(ficheiro);
                row[2] = ficheiro;
                table.Rows.Add(row);
            }
        }
        dataGridView1.DataSource = table;
        dataGridView1.Columns[2].Visible = false;
    }
    private void dataGridView1_DoubleClick(object sender, EventArgs e)
    {
        FormFotos2 myForm = new FormFotos2();
        string imageName = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        Image img;
        img = Image.FromFile(imageName);
        myForm.pictureBox1.Image = img;
        myForm.ShowDialog();
    }
