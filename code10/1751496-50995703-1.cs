    public partial class frmMain : Form
    {
        private readonly AgreementRepository _agreementRepository;
        public frmMain()
        {
            _agreementRepository = new AgreementRepository();
            InitializeComponent();
            txtDateTime.Text = DateTime.Now.ToString();
            txtUsername.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            btnClose.Visible = false;
            chkAgree.Visible = true;
            rtbSecurityAwareness.LoadFile("Security Awareness.rtf");
            this.Load += Form1_Load;
        }
		private void Form1_Load(object sender, EventArgs e)
		{
			var lastAgreement = _agreementRepository.GetLastAgreementForCurrentUser();
			// NOTE: The following condition deals with the fact that lastAgreement could be null
			if (lastAgreement > DateTime.Now.AddMonths(-6))
			{
				Close(); // or Environment.Exit; depends what you need
			}
		}
        private void chkAgree_CheckedChanged(object sender, EventArgs e)
        {
            btnClose.Visible = chkAgree.Checked; // simplification of your posted code
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _agreementRepository.AppendAgreementForCurrentUser();
            Environment.Exit(0); // Would 'Close()' be enough?
        }
