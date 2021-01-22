    public Form1 mainForm;
    private void Form2_Closing(object sender, DontRememberWhatItsCalledEventArgs e)
    {
        mainForm.defaultValue = textBox1.Text;
    }
}
