csharp
public static class ButtonExtensions
{
    /// <summary>
    /// Performs a click on the button.<br/>
    /// This is the WPF-equivalent of the Windows Forms method "<see cref="M:System.Windows.Forms.Button.PerformClick" />".
    /// <para>This simulates the same behaviours as the button was clicked by the user by keyboard or mouse:<br />
    /// 1. The raising the ClickEvent.<br />
    /// 2.1. Checking that the bound command can be executed, calling <see cref="ICommand.CanExecute" />, if a command is bound.<br />
    /// 2.2. If command can be executed, then the <see cref="ICommand.Execute(object)" /> will be called and the optional bound parameter is p
    /// </para>
    /// </summary>
    /// <param name="sourceButton">The source button.</param>
    /// <exception cref="ArgumentNullException">sourceButton</exception>
    public static void PerformClick(this Button sourceButton)
    {
        // Check parameters
        if (sourceButton == null)
            throw new ArgumentNullException(nameof(sourceButton));
        // 1.) Raise the Click-event
        sourceButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
        // 2.) Execute the command, if bound and can be executed
        ICommand boundCommand = sourceButton.Command;
        if (boundCommand != null)
        {
            object parameter = sourceButton.CommandParameter;
            if (boundCommand.CanExecute(parameter) == true)
                boundCommand.Execute(parameter);
        }
    }
}
