    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<BaseForm, BaseFormMiddle2>))]   // BaseFormMiddle2 explained below
    public abstract class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }
        public abstract void SomeAbstractMethod();
    }
    public class Form1 : BaseForm   // Form1 is the form to be designed. As you see it's clean and you do NOTHING special here (only the the normal abstract method(s) implementation!). The developer of such form(s) doesn't have to know anything about the abstract base form problem. He just writes his form as usual.
    {
        public Form1()
        {
            InitializeComponent();
        }
        public override void SomeAbstractMethod()
        {
            // implementation of BaseForm's abstract method
        }
    }
