    //the xaml
    <local:EcranFiche x:Class="VLEva.SIFEval.Ecrans.UC_BatimentAgricole" 
                      xmlns:local="clr-namespace:VLEva.SIFEval.Ecrans"
                      ...>
        ...
    </local:EcranFiche>
    // the usercontrol code behind
    public partial class UC_BatimentAgricole : EcranFiche, IEcranFiche
    {
        ...
    }
    // the interface
    public interface IEcranFiche
    {
       ...
    }
    // base class containing common implemented methods
    public class EcranFiche : UserControl
    {
        ... (ex: common interface implementation)
    }
