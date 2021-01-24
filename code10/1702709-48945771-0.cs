    public partial class EmployeeResultViewCell : CustomViewCell
    {
        /// <summary>
        ///   The <see cref="DeleteCommand" /> bindable property.
        /// </summary>
        public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(nameof(SealCheckListPage.DeleteCommand), typeof(ICommand), typeof(SealCheckListPage), default(ICommand));
        /// <summary>
        ///   Gets or sets the DeleteCommand that is called when we'd like to delete an employee.
        /// </summary>
        public ICommand DeleteCommand
        {
            get => (ICommand)this.GetValue(SealCheckListPage.DeleteCommandProperty);
            set => this.SetValue(SealCheckListPage.DeleteCommandProperty, value);
        }
        private void MenuItemDelete_Clicked(object sender, System.EventArgs e)
        {
            DeleteCommand?.Execute(BindingContext);
        }
    }
