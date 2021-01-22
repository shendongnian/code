    double d;
    if(!Double.TryParse(textBox2.Text, out d)){
        return; // or alert, or whatever.
    }
    
    guy1 = new Guy() ;
    guy1.guyname = textBox1.Text;                
    guy1.guycash = d;
