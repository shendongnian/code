    public partial class GeneratorWindow : Window
    {
        //Private members
        int m_numberOfPoints;
        int m_mainPDC;
          
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ABB_Rapid_Generator.GeneratorWindow" /> class.
        /// </summary>
        public GeneratorWindow(int mainPDC,int numberOfPoints)
        {
            this.InitializeComponent();
            this.m_mainPDC = mainPDC;
            this.m_numberOfPoints = numberOfPoints;
        }
    
        /// <summary>
        /// Gets or sets the number of points.
        /// </summary>
        public int NumberOfPoints 
        { 
          get{ return m_numberOfPoints; }
          set{ m_numberOfPoints = values; }
        }
        /// <summary>
        /// Gets or sets the main PDC.
        /// </summary>
        public int MainPDC
        { 
          get{ return m_mainPDC; }
          set{ m_mainPDC= values; }
        }
      
        public void Print()
        {
            Console.WriteLine(this.NumberOfPoints);
            Console.WriteLine(this.MainPDC);
        }
    }
