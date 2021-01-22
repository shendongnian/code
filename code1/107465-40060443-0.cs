    public Form1()
    {
        InitializeComponent();
        var holder = PositionHolderAlgorithmComboBox;
        holder.Visible = false;
        fixedKAlgorithmComboBox = new MiCluster.UI.Controls.AlgorithmComboBox(c => c.CanFixK);
        fixedKAlgorithmComboBox.Name = "fixedKAlgorithmComboBox";
        fixedKAlgorithmComboBox.Location = holder.Location;
        fixedKAlgorithmComboBox.Size = new System.Drawing.Size(holder.Width, holder.Height);
        holder.Parent.Controls.Add(fixedKAlgorithmComboBox);
    }
