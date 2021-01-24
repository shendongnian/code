    public partial class Form1 : Form
    {
        private static Ship[] submarine;
        .
        .
        .
        private void Form1_Load(object sender, EventArgs e)
        {
            // forms load == game starts
            submarine = new Ship[100]; 
            submarine[0].create_ship(140, 200); // create first ship with only two 
            parameters: position X and Y on future map
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            submarine[0].move(90, 15); // ERROR: compiler shows "The name 'submarine' 
            does not exist in the current context
        }
