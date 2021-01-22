		private static object missing = System.Reflection.Missing.Value;
		/// <summary>
		/// Deletes the line in which there is a selection.
		/// </summary>
		/// <param name="application">Instance of Application object.</param>
		private void DeleteCurrentSelectionLine(_Application application)
		{
			object wdLine = WdUnits.wdLine;
			object wdCharacter = WdUnits.wdCharacter;
			object wdExtend = WdMovementType.wdExtend;
			object count = 1;
			Selection selection = application.Selection;
			selection.HomeKey(ref wdLine, ref missing);
			selection.MoveDown(ref wdLine, ref count, ref wdExtend);
			selection.Delete(ref wdCharacter, ref missing);
		}
