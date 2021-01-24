    private void frmdbSiswa_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
     {
        db = new SiswaSMSEntities();
        tabelSiswaBindingSource.DataSource = db.Tabel_Siswa.ToList();
        agamaSiswaBindingSource.DataSource = db.Agama_Siswa.ToList();
        kelasBindingSource.DataSource = db.Kelas.ToList();
        jenisKelaminBindingSource.DataSource = db.Jenis_Kelamin.ToList();
        dataGridViewSiswa.DataSource = db.Tabel_Siswa.ToList();//to show the datagridview
        dataGridViewSiswa.DataBind();
        cboKelas.DataSource = db.Kelas.ToList();//combobox
        cboKelas.DataBind();
       }
    }
 
    private void cboKelas_SelectionChangeCommitted(object sender, EventArgs e)
    {
        dataGridViewSiswa.DataSource = db.Tabel_Siswa.Where(x => x.IdKelas == cboKelas.SelectedIndex).ToList();
     dataGridViewSiswa.DataBind();
    }
