    public async void Form1_Load(object sender, EventArgs e) {
        for (int i = 1; i < total; i++){
           for (int row = 0; row < 4; row++){
              for (int col = 0; col < 4; col++){ 
                   pixel = block[i][row][col];
                   label1.Text = pixel.R.ToString("X");
                   await Task.Delay();
              }
           }
        }
    }
