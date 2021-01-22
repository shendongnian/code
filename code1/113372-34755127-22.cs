    public class VormenVerwijderdActie : Actie
	{
		public VormenVerwijderdActie(Vorm[] Vormen, Tekening tek)
			: base(Vormen)
		{
			this.tek = tek;
		}
		private Tekening tek;
		public override void Redo()
		{
			tek.Vormen.CanRaiseEvents = false;
			foreach(Vorm v in Vormen)
				tek.Vormen.Remove(v);
			tek.Vormen.CanRaiseEvents = true;
		}
		public override void Undo()
		{
			tek.Vormen.CanRaiseEvents = false;
			foreach(Vorm v in Vormen)
				tek.Vormen.Add(v);
			tek.Vormen.CanRaiseEvents = true;
		}
	}
