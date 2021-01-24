    using WindowsInput;
    using WindowsInput.Native;
    using System.Windows.Forms;
    
    getInputField().Click();
    Clipboard.SetText("text");
    InputSimulator sim = new InputSimulator();
    sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V);
