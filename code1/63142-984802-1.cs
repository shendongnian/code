    private void Form1_Load(object sender, EventArgs e)
    {
        maskedTextBox1.Mask = "00/00/0000";
        maskedTextBox1.ValidatingType = typeof(System.DateTime);
        maskedTextBox1.TypeValidationCompleted += new TypeValidationEventHandler
           (maskedTextBox1_TypeValidationCompleted);
    }
    private void TypeValidationCompletedHandler(object sender, TypeValidationEventArgs e )
    {
        e.Cancel = !e.IsValidInput &&
            this.maskedTextBox1.MaskedTextProvider.AssignedEditPositionCount == 0;
    }
