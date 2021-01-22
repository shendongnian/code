    <%@ Page Language="C#" ValidateRequest="false" %>
    
    <%@ Import Namespace="Microsoft.Ajax.Utilities" %>
    
    <script runat="server">
    
        // Webform harness for Microsoft Ajax Minifier 4
            
        // this source code placed in Public Domain by Sky Sanders
        // http://skysanders.net/subtext
        
        // Install Microsoft Ajax Minifier 4 from http://aspnet.codeplex.com/releases/view/40584
        // add a reference to C:\Program Files (x86)\Microsoft\Microsoft Ajax Minifier 4\AjaxMin.dll    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var settings = new CodeSettings();
                MinifyCode = settings.MinifyCode;
                OutputMode = settings.OutputMode;
                CollapseToLiteral = settings.CollapseToLiteral;
                CombineDuplicateLiterals = settings.CombineDuplicateLiterals;
                EvalTreatment = settings.EvalTreatment;
                IndentSize = settings.IndentSize;
                InlineSafeStrings = settings.InlineSafeStrings;
                LocalRenaming = settings.LocalRenaming;
                MacSafariQuirks = settings.MacSafariQuirks;
                PreserveFunctionNames = settings.PreserveFunctionNames;
                RemoveFunctionExpressionNames = settings.RemoveFunctionExpressionNames;
                RemoveUnneededCode = settings.RemoveUnneededCode;
                StripDebugStatements = settings.StripDebugStatements;
            }
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = new CodeSettings
                {
                    MinifyCode = MinifyCode,
                    OutputMode = OutputMode,
                    CollapseToLiteral = CollapseToLiteral,
                    CombineDuplicateLiterals = CombineDuplicateLiterals,
                    EvalTreatment = EvalTreatment,
                    IndentSize = IndentSize,
                    InlineSafeStrings = InlineSafeStrings,
                    LocalRenaming = LocalRenaming,
                    MacSafariQuirks = MacSafariQuirks,
                    PreserveFunctionNames = PreserveFunctionNames,
                    RemoveFunctionExpressionNames = RemoveFunctionExpressionNames,
                    RemoveUnneededCode = RemoveUnneededCode,
                    StripDebugStatements = StripDebugStatements
                };
                var min = new Minifier();
                OutputTextBox.Text = min.MinifyJavaScript(InputTextBox.Text, settings);
                ResultsLabel.Text = string.Format("Before:{0}, After:{1}", InputTextBox.Text.Length,
                                                  OutputTextBox.Text.Length);
            }
            catch (Exception ex)
            {
                OutputTextBox.Text = ex.ToString();
            }
        }
    
    
        public bool CollapseToLiteral
        {
            get { return CollapseToLiteralCheckBox.Checked; }
            set { CollapseToLiteralCheckBox.Checked = value; }
        }
    
        public bool CombineDuplicateLiterals
        {
            get { return CombineDuplicateLiteralsCheckBox.Checked; }
            set { CombineDuplicateLiteralsCheckBox.Checked = value; }
        }
    
        public EvalTreatment EvalTreatment
        {
            get { return (EvalTreatment)Enum.Parse(typeof(EvalTreatment), EvalTreatmentDropDownList.SelectedValue); }
            set
            {
                EvalTreatmentDropDownList.SelectedIndex =
                    EvalTreatmentDropDownList.Items.IndexOf(EvalTreatmentDropDownList.Items.FindByText(value.ToString()));
            }
        }
    
        public int IndentSize
        {
            get
            {
                int result;
                return int.TryParse(IndentSizeTextBox.Text, out result) ? result : 0;
            }
            set { IndentSizeTextBox.Text = value.ToString(); }
        }
    
        public bool InlineSafeStrings
        {
            get { return InlineSafeStringsCheckBox.Checked; }
            set { InlineSafeStringsCheckBox.Checked = value; }
        }
    
        public LocalRenaming LocalRenaming
        {
            get { return (LocalRenaming)Enum.Parse(typeof(LocalRenaming), LocalRenamingDropDownList.SelectedValue); }
            set
            {
                LocalRenamingDropDownList.SelectedIndex =
                    LocalRenamingDropDownList.Items.IndexOf(LocalRenamingDropDownList.Items.FindByText(value.ToString()));
            }
        }
    
        public bool MacSafariQuirks
        {
            get { return MacSafariQuirksCheckBox.Checked; }
            set { MacSafariQuirksCheckBox.Checked = value; }
        }
    
        public bool MinifyCode
        {
            get { return MinifyCodeCheckBox.Checked; }
            set { MinifyCodeCheckBox.Checked = value; }
        }
    
        public OutputMode OutputMode
        {
            get { return (OutputMode)Enum.Parse(typeof(OutputMode), OutputModeDropDownList.SelectedValue); }
            set
            {
                OutputModeDropDownList.SelectedIndex =
                    OutputModeDropDownList.Items.IndexOf(OutputModeDropDownList.Items.FindByText(value.ToString()));
            }
        }
    
        public bool PreserveFunctionNames
        {
            get { return PreserveFunctionNamesCheckBox.Checked; }
            set { PreserveFunctionNamesCheckBox.Checked = value; }
        }
    
        public bool RemoveFunctionExpressionNames
        {
            get { return RemoveFunctionExpressionNamesCheckBox.Checked; }
            set { RemoveFunctionExpressionNamesCheckBox.Checked = value; }
        }
    
        public bool RemoveUnneededCode
        {
            get { return RemoveUnneededCodeCheckBox.Checked; }
            set { RemoveUnneededCodeCheckBox.Checked = value; }
        }
    
        public bool StripDebugStatements
        {
            get { return StripDebugStatementsCheckBox.Checked; }
            set { StripDebugStatementsCheckBox.Checked = value; }
        }
            
    </script>
    
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <style type="text/css">
            input, select
            {
                font-family: Sans-Serif;
                font-size: 8pt;
            }
            body
            {
                font-family: Sans-Serif;
                font-size: 8pt;
            }
            .textIn
            {
                height: 200px;
            }
            .textOut
            {
                height: 400px;
            }
            .text
            {
                width: 800px;
                font-size: 1.2em;
            }
            .options
            {
                float: left;
                width: 200px;
            }
            .results
            {
                margin: 2px;
                border: solid 1px green;
                font-size: 9pt;
            }
            .inout .options
            {
                float: left;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
            <div class="options">
                <asp:CheckBox ID="CollapseToLiteralCheckBox" runat="server" Text="CollapseToLiteral" />
                <asp:Label ID="Label13" runat="server" Text=" [?]" ToolTip="convert “new Object()” to “{}” and “new Array()” to “[].” And of course, “new Array(1,2,3,4,5)” becomes “[1,2,3,4,5]” and “new Array(“foo”)” becomes “[“foo”]”. However, “new Array(5)” does not get minified, because that makes an array with five initial slots – it’s not the same as [5]."></asp:Label><br />
                <asp:CheckBox ID="CombineDuplicateLiteralsCheckBox" runat="server" Text="CombineDuplicateLiterals" /><asp:Label
                    ID="Label12" runat="server" Text=" [?]" ToolTip="combine duplicate literals into local variables."></asp:Label><br />
                <asp:CheckBox ID="InlineSafeStringsCheckBox" runat="server" Text="InlineSafeStrings" /><asp:Label
                    ID="Label11" runat="server" Text=" [?]" ToolTip="No documentation found"></asp:Label><br />
                <asp:CheckBox ID="MacSafariQuirksCheckBox" runat="server" Text="MacSafariQuirks" /><asp:Label
                    ID="Label10" runat="server" Text=" [?]" ToolTip="There are two quirks that Safari on the Mac (not the PC) needed: throw statements always seem to require a terminating semicolon; and if statements that only contains a single function declaration need to surround that function declaration with curly-braces. Basically, if you want your code to always work in Safari, set this to true. If you don’t care about Safari (for instance, in a corporate environment where the browser your users can use is highly restricted), setting this value to false might save a few bytes."></asp:Label><br />
                <asp:CheckBox ID="MinifyCodeCheckBox" runat="server" Text="MinifyCode" />
                <asp:Label ID="Label9" runat="server" Text=" [?]" ToolTip="no docs found but is self describing option"></asp:Label><br />
                <asp:CheckBox ID="PreserveFunctionNamesCheckBox" runat="server" Text="PreserveFunctionNames" /><asp:Label
                    ID="Label8" runat="server" Text=" [?]" ToolTip="no docs found"></asp:Label><br />
                <asp:CheckBox ID="RemoveFunctionExpressionNamesCheckBox" runat="server" Text="RemoveFunctionExpressionNames" /><asp:Label
                    ID="Label7" runat="server" Text=" [?]" ToolTip="no docs found"></asp:Label><br />
                <asp:CheckBox ID="RemoveUnneededCodeCheckBox" runat="server" Text="RemoveUnneededCode" /><asp:Label
                    ID="Label6" runat="server" Text=" [?]" ToolTip=" Should be set to true for maximum minification. Removes unreferenced local functions (not global functions, though), unreferenced function parameters, quotes around object literal field names that won’t be confused with reserved words, and it does some interesting things with switch statements. For instance, if the default case is empty (just a break), it removes it altogether. If there is no default case, it also removes other empty case statements. It also removes break statements after return statements (unreachable code)."></asp:Label><br />
                <asp:CheckBox ID="StripDebugStatementsCheckBox" runat="server" Text="StripDebugStatements" />
                <asp:Label ID="Label5" runat="server" Text=" [?]" ToolTip="removes “debugger” statements, any calls into certain namespaces like $Debug, Debug, Web.Debug or Msn.Debug. also strips calls to the WAssert function."></asp:Label>
                <br />
                <asp:Label ID="OutputModeLabel" runat="server" Text="OutputMode"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text=" [?]" ToolTip="SingleLine minifies everything to a single line. MultipleLines breaks the minified code into multiple lines for easier reading (won’t drive you insane trying to debug a single line). The only difference between the two outputs is whitespace. (see also: IndentSize)."></asp:Label>
                <br />
                <asp:DropDownList ID="OutputModeDropDownList" runat="server">
                    <asp:ListItem Value=" SingleLine"> SingleLine</asp:ListItem>
                    <asp:ListItem Value="MultipleLines">MultipleLines</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="LocalRenamingLabel" runat="server" Text="LocalRenaming"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text=" [?]" ToolTip=" renaming of locals. There are a couple settings: KeepAll is the default and doesn’t rename variables or functions at all. CrunchAll renames everything it can. In between there is KeepLocalizationVars, which renames everything it can except for variables starting with L_. Those are left as-is so localization efforts can continue on the minified code."></asp:Label>
                <br />
                <asp:DropDownList ID="LocalRenamingDropDownList" runat="server">
                    <asp:ListItem>KeepAll</asp:ListItem>
                    <asp:ListItem>KeepLocalizationVars</asp:ListItem>
                    <asp:ListItem>CrunchAll</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="EvalTreatmentLabel" runat="server" Text="EvalTreatment" AssociatedControlID="EvalTreatmentDropDownList"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text=" [?]" ToolTip="Normally an eval statement can contain anything, including references to local variables and functions. If it is expected to do so, when the tool encounters an eval statement, that scope and all parent scopes cannot take advantage of local variable and function renaming because things could break when the eval is evaluated and the references are looked up. To reduce the amount of resulting minification but make sure that all possible references in evaluated code will hold true, use the MakeAllSafe value. However, sometimes the developer knows that he’s not referencing local variables in his eval (like when only evaluating JSON objects), and this switch can be set to Ignore to make sure you get the maximum reduction in resulting code size. Or alternatively, if the developer knows the code being evaluated will only access local variables and functions in the current scope and nowhere else, the MakeImmediateSafe value can be specified and all parent scopes will still rename their locals. Very dangerous setting; should only be used when you are certain of all possible behavior of evaluated code."></asp:Label><br />
                <asp:DropDownList ID="EvalTreatmentDropDownList" runat="server">
                    <asp:ListItem>Ignore</asp:ListItem>
                    <asp:ListItem>MakeImmediateSafe</asp:ListItem>
                    <asp:ListItem>MakeAllSafe</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="IndentSizeLabel" runat="server" Text="IndentSize"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text=" [?]" ToolTip=" for the multi-line output feature, how many spaces to use when indenting a block (see OutputMode)."></asp:Label>
                <br />
                <asp:TextBox ID="IndentSizeTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="GO" /><br />
                <asp:Label ID="ResultsLabel" runat="server" Text=" " CssClass="results"></asp:Label>
            </div>
            <div class="inout">
                <asp:TextBox ID="InputTextBox" runat="server" TextMode="MultiLine" CssClass="text textIn"></asp:TextBox><br />
                <asp:TextBox ID="OutputTextBox" runat="server" TextMode="MultiLine" CssClass="text textOut"></asp:TextBox>
            </div>
        </div>
        </form>
    </body>
    </html>
