     private void button1_Click(object sender, EventArgs e) {
       string[] AnalyteNames = new string[]{
         "NA", "K", "CL", "TCO2", "BUN", "CREA", "EGFR", "GLU", "CA", "ANG", "HCT", "HGB" };
       // Create checkboxes with provided titles
       AnalyteListCheckBoxes.Items.AddRange(AnalyteNames);
     }
