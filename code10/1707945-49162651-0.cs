	public class MyPrintInteractionControllerDelegate : NSObject, IUIPrintInteractionControllerDelegate
	{
		[Export("printInteractionController:chooseCutterBehavior:")]
		public UIPrinterCutterBehavior ChooseCutterBehavior(UIPrintInteractionController printInteractionController, NSNumber[] availableBehaviors)
		{
            // What does this printer support?
			foreach (var whatsAvailable in availableBehaviors)
			{
				var nameofEnum = Enum.GetName(typeof(UIPrinterCutterBehavior), whatsAvailable.Int16Value);
				Console.WriteLine($"AvailableBehavior : {nameofEnum}");
			}
            // If the printer supports CutAfterEachJob, use it, otherwise use the whatever the printer default is.
			if (availableBehaviors.Contains((int)UIPrinterCutterBehavior.CutAfterEachJob))
				return UIPrinterCutterBehavior.CutAfterEachJob;
			else
				return UIPrinterCutterBehavior.PrinterDefault;
		}
		//~~~ other delegate methods ~~~
	}
