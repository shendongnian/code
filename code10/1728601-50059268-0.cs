    public partial class GraphForm : Form
    {
        private ILInArray<double> CrossCorrExpMatrixReShiftedILN;
        public GraphForm(ILInArray<double> pCrossCorrExpMatrixReShiftedILN)
        {
            InitializeComponent();
            CrossCorrExpMatrixReShiftedILN = pCrossCorrExpMatrixReShiftedILN;
        }
        private void GraphForm_Load(object sender, EventArgs e)
        {
            ILInArray<double> GraphData = CrossCorrExpMatrixReShiftedILN;
            //Here I use GraphData to plot the surface
        }
