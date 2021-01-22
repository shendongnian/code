    **SampleControl.cs**
        public class SampleControl : SpringImmediacyControl, INamingContainer
        {
            public string Text
            {
                get;
                set;
            }
            protected string InjectedText
            {
                get;
                set;
            }
            public SampleControl()
                : base()
            {
                Text = "Hello world";
            }
            protected override void RenderContents(HtmlTextWriter output)
            {
                output.Write(string.Format("{0} {1}", Text, InjectedText));
            }
        }
    **Spring.config**
        <objects xmlns="http://www.springframework.net">
            <object type="MyProject.SampleControl, MyAssembly">
                <property name="InjectedText" value="from Spring.NET" />
            </object>
        </objects>
