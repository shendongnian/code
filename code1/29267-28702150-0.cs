	public class RegexTextBox : TextBox
	{
		public RegexTextBox() { }
		
		#region Regex
		
		private string lastText;
		
		[Browsable(false)]
		public virtual Regex Regex { get; set; }
		
		[DefaultValue(null)]
		[Category("Behavior")]
		[Description("Sets the regular expression governing the input allowed for this control.")]
		public virtual string RegexString {
			get {
				return this.Regex == null ? string.Empty : this.Regex.ToString();
			}
			set {
				if(value == null || value.Length == 0)
					this.Regex = null;
				else
					this.Regex = new Regex(value);
			}
		}
		
		protected override void OnTextChanged(EventArgs e) {
			if(this.Regex != null && !this.Regex.IsMatch(this.Text)) {
				int pos = this.SelectionStart - this.Text.Length + (lastText ?? string.Empty).Length;
				this.Text = lastText;
				this.SelectionStart = Math.Max(0, pos);
			}
			
			lastText = this.Text;
			
			base.OnTextChanged(e);
		}
		
		#endregion
	}
