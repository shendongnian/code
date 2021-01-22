    public class Wizard
    {
        private WizardPage<MyControl> Page1;
        public Wizard(MyControl control)
        {
            this.Page1 = new WizardPage<MyControl>(control);
        }
    }
