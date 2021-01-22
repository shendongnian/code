       public partial class Form1 : Form
       {
          public Form1()
          {
             InitializeComponent();
    
             // Create adapter and place a request
             MergeFactoryTarget target = new Adapter<AdapteeA, AdapteeB>();
             target.InterfaceACall();
             target.InterfaceBCall();
          }
       }
    
       /// <summary>
       /// The 'Target' class
       /// </summary>
       public class MergeFactoryTarget
       {
          public virtual void InterfaceACall()
          {
             Console.WriteLine("Called Interface A Function()");
          }
    
          public virtual void InterfaceBCall()
          {
             Console.WriteLine("Called Interface B Function()");
          }
       }
    
       /// <summary>
       /// The 'Adapter' class
       /// </summary>
       class Adapter<AdapteeType1, AdapteeType2> : MergeFactoryTarget
          where AdapteeType1 : IAdapteeA
          where AdapteeType2 : IAdapteeB
       {
          private AdapteeType1 _adapteeA = Activator.CreateInstance<AdapteeType1>();
          private AdapteeType2 _adapteeB = Activator.CreateInstance<AdapteeType2>();
    
          public override void InterfaceACall()
          {
             _adapteeA.InterfaceOneMethod();
          }
    
          public override void InterfaceBCall()
          {
             _adapteeB.InterfaceTwoMethod();
          }
       }
    
       /// <summary>
       /// AdapteeA Interface
       /// </summary>
       interface IAdapteeA
       {
          void InterfaceOneMethod();
       }
    
       /// <summary>
       /// AdapteeB Interface
       /// </summary>
       interface IAdapteeB
       {
          void InterfaceTwoMethod();
       }
    
       /// <summary>
       /// The 'AdapteeA' class
       /// </summary>
       class AdapteeA : IAdapteeA
       {
          public void InterfaceOneMethod()
          {
             Console.WriteLine("Called InterfaceOneMethod()");
          }
       }
    
       /// <summary>
       /// The 'AdapteeB' class
       /// </summary>
       class AdapteeB : IAdapteeB
       {
          public void InterfaceTwoMethod()
          {
             Console.WriteLine("Called InterfaceTwoMethod()");
          }
       }
