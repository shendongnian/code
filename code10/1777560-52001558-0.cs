    public partial class FormPesquisaFotos : Form
    {
    	// We create the DataTable here so we can create the new inside the Worker_DoWork and use it also on the Worker_RunWorkerCompleted
    	DataTable tableWithPhotos;
        private void button1_Click(object sender, EventArgs e)
        {
    		// Make the progressBar1 to look like its allways loading something
            progressBar1.Style = ProgressBarStyle.Marquee;
    		// Make it here visible
    		progressBar1.Visible = true;
            var worker = new BackgroundWorker();
    
            // Evento que corre em background
            worker.DoWork += this.Worker_DoWork;
    
            // Evento que corre depois do concluído o BackgroundWorker
            worker.RunWorkerCompleted += this.Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }
    	
    	// The reason for having this here was to work with the progress bar and to search for the photos and it will not block the UI Thread
    	// My advice is to have them here and pass them to the next form with a constructor
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
    		// We must create a list for all the files that the search it will find
    		List<string> filesList = new List<string>();
    		// Create the new DataTable to be used
    		tableWithPhotos = new DataTable();		
    		table.Columns.Add("Nome e formato do ficheiro (duplo clique para visualizar a imagem)");
            table.Columns.Add("Caminho ( pode ser copiado Ctrl+C )");
    		
    		// se pretendermos pesquisar em várias pastas
            var diretorios = new List<string>() { @"\\Server\folder1\folder2" };
    
            // se pretendermos pesquisar as várias extensões
            var extensoes = new List<string>() {"*.jpg","*.bmp","*.png","*.tiff","*.gif"};
    		
    		// This 2 foreach are to search for the files with the extension that is on the extensoes and on all directories that are on diretorios
            // In for foreach we go through all the extensions that we want to search
    		foreach (string entryExtensions in extensoes)
    		{
    			// Now we must go through all the directories to search for the extension that is on the entryExtensions
    			foreach (string entryDirectory in diretorios)
    			{
    				// SearchOption.AllDirectories search the directory and sub directorys if necessary
    				// SearchOption.TopDirectoryOnly search only the directory
    				filesList.AddRange(Directory.GetFiles(entryDirectory, entryExtensions, SearchOption.AllDirectories));
    			}
    		}
    		
    		// And now here we will add all the files that it has found into the DataTable
    		foreach (string entryFiles in filesList)
    		{
    			DataRow row = tableWithPhotos.NewRow();
    			row[0] = Path.GetFileName(entryFiles);
    			row[1] = entryFiles;
    			tableWithPhotos.Rows.Add(row);
    		}
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // With the new constructor on the FormResultadosFotos, we pass the table like this so the form can receive it
    		progressBar1.Visable = false;
            var NovoForm = new FormResultadosFotos(tableWithPhotos);
            NovoForm.Show();
        }
    }
