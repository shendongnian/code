    namespace Module10Project
    {
        public partial class frmRadioStar : Form
        {
            enum OperationType
            {
                Add, Subtract, Multiply, Divide, Module
            }
                
            public bool isPresent(TextBox txtLeft, TextBox txtRight)
            {
                if(txtLeft.Text == "" || txtRight.Text == "")
                {
                    lblMessage.Text = "Please enter a number into the Textbox";
                    return false;
                }
                else
                {
                    return true;
                }
            }
    
            public bool divideByZero(TextBox Left, TextBox Right)
            {
                int rightOperand = Convert.ToInt32(Right.Text);
    
                if(rightOperand == 0)
                {
                    lblMessage.Text = "Unable to divide by 0";
                    return true;
                }
                else
                {
                    return false;
                }
            }
    
            private int equationCalculation(int Left, int Right, OperationType operation)
            {
                switch(operation)
                {
                    case OperationType.Add:
                        return Left + Right;
                    case OperationType.Subtract:
                        return Left - Right;
                    case OperationType.Multiply:
                        return Left * Right;
                    case OperationType.Divide:
                        return Left / Right;
                    case OperationType.Module:
                        return Left % Right;
                }
                return 0;
            }
    
    
            public bool isValid(TextBox Left, TextBox Right)
            {
                return isPresent(Left, Right) && !divideByZero(Left, Right);
            }
            public frmRadioStar()
            {
                InitializeComponent();
            }
    
            private void btnExit_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    
            private void btnReset_Click(object sender, EventArgs e)
            {
                txtLeft.Text = "";
                txtRight.Text = "";
                lblMessage.Text = "";
                chkVerbose.Checked = true;
                btnAdd.Focus();
                txtLeft.Focus();
            }
    
            private void btnCalculate_Click(object sender, EventArgs e)
            {
                try
                {
                    if(isValid(txtLeft, txtRight))
                    {
                        int result = 0;
                        int leftOperand = Convert.ToInt32(txtLeft.Text);
                        int rightOperand = Convert.ToInt32(txtRight.Text);
    
                        if (btnAdd.Checked)
                        {
                            result = equationCalculation(leftOperand, rightOperand, OperationType.Add);
                            lblMessage.Text = chkVerbose.Checked ? $"{leftOperand} + {rightOperand} = {result}" : $"The Answer is: {result}";
                        }
                        else if(btnSubtract.Checked)
                        {
                            result = equationCalculation(leftOperand, rightOperand, OperationType.Subtract);
                            lblMessage.Text = chkVerbose.Checked ? $"{leftOperand} - {rightOperand} = {result}" : $"The Answer is: {result}";
                        }
                        else if(btnMultiply.Checked)
                        {
                            result = equationCalculation(leftOperand, rightOperand, OperationType.Multiply);
                            lblMessage.Text = chkVerbose.Checked ? $"{leftOperand} * {rightOperand} = {result}" : $"The Answer is: {result}";
                        }
                        else if(btnDivide.Checked)
                        {
                            result = equationCalculation(leftOperand, rightOperand, OperationType.Divide);
                            lblMessage.Text = chkVerbose.Checked ? $"{leftOperand} / {rightOperand} = {result}" : $"The Answer is: {result}";
                        }
                        else if(btnMod.Checked)
                        {
                            result = equationCalculation(leftOperand, rightOperand, OperationType.Module);
                            lblMessage.Text = chkVerbose.Checked ? $"{leftOperand} % {rightOperand} = {result}" : $"The Answer is: {result}";
                        }
                    }
                }
                catch(Exception ex)
                {
    
                }
           }
        }
    }
