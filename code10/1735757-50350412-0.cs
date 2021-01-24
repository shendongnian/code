    float flradius;
    float flfactual;
    float flfmax;
    float flfos;
    float slvalue;
    double flslidervalue; //Create the global variable so it's accessible from 
                          //all methods
    private void btnCalculate_Click(object sender, RoutedEventArgs e)
    {
        flfactual = flfmax / flfos;
        //output Flfmax back to form
        txtFmax.Text = flfmax.ToString();
        //output Flfactual back to form
        txtFactual.Text = flfactual.ToString();
    }
    private void fosslider_ValueChanged(object sender, 
                                        RoutedPropertyChangedEventArgs<double> e)
    {
        txtSlider.Text = fosslider.Value.ToString();
        //Add this line, this will parse your string to a double that you can 
        //access by calling flslidervalue 
        Double.TryParse(fosslider.Value.ToString(), out flslidervalue); 
    } 
