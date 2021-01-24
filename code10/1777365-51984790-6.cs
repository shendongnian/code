    // Lets create a DataTable variable to be access on the Worker_DoWork and then on the Worker_RunWorkerCompleted
    private DataTable tableOfPhotos;
    
    private void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
        // Search for the photos here and then add them to the DataTable
    	this.tableOfPhotos = new DataTable();
    	tableOfPhotos.Columns.Add("Nome e formato do ficheiro (duplo clique para visualizar a imagem)");
    	tableOfPhotos.Columns.Add("Caminho ( pode ser copiado Ctrl+C )");
    	foreach (string diretorio in diretorios)
    	{
    		// se pretendermos pesquisar em várias pastas
    		List<string> diretorios = new List<string>()
    		{@"\\Server\folder01\folder02"};
    
    		// se pretendermos pesquisar as várias extensões
    		List<string> extensoes = new List<string>()
    		{"*.jpg","*.bmp","*.png","*.tiff","*.gif"};
    		
    		var ficheiros = Directory.EnumerateFiles(diretorio, "*", SearchOption.AllDirectories).
    			Where(r => extensoes.Contains(Path.GetExtension(r.ToLower())));
    		foreach (var ficheiro in ficheiros)
    		{
    			DataRow row = tableOfPhotos.NewRow();
    			row[0] = Path.GetFileName(ficheiro);
    			row[1] = ficheiro;
    			tableOfPhotos.Rows.Add(row);
    		}
    	}
    }
    
    private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // You can put the code here to open the new form and such
    	FormResultadosFotos NovoForm = new FormResultadosFotos(this.tableOfPhotos);
    	NovoForm.Show();
    }
    
    
    // Constructor that will receive the DataTable and put it into the dataGridView1, it should be added on the Form FormResultadosFotos
    Public FormResultadosFotos(DataTable table)
    {
    	InitializeComponent();
    	// In here we will tell the where is the source for the dataGridView1
    	this.dataGridView1.DataSource = table;
    }
