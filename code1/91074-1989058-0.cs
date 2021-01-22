    public class SampleViewModel: BaseViewModelStub
    {
        public string Name { get; set; }
        [UiCommand]
        public void HelloWorld()
        {
            MessageBox.Show("Hello World!");
        }
        [UiCommand]
        public void Print()
        {
            MessageBox.Show(String.Concat("Hello, ", Name, "!"), "SampleViewModel");
        }
        public bool CanPrint()
        {
            return !String.IsNullOrEmpty(Name);
        }
    }
