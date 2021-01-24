	public class Unit
	{
		private Dictionary<(UnitType, AttackType), Action<Unit, Unit>> _validAttacks;
	
		public Unit()
		{
			_validAttacks = new Dictionary<(UnitType, AttackType), Action<Unit, Unit>>()
			{
				{ (UnitType.Air, AttackType.Air), (s, o) => MissleAttack(s, o) },
				{ (UnitType.Air, AttackType.Ground), (s, o) => MissleAttack(s, o) },
				{ (UnitType.Ground, AttackType.Ground), (s, o) => TankAttack(s, o) },
				{ (UnitType.Water, AttackType.Water), (s, o) => TorpedoAttack(s, o) },
				{ (UnitType.Water, AttackType.Air), (s, o) => IcbmAttack(s, o) },
			};
		}
		
		public UnitType unitType;
		public AttackType attackType;
	
		void OnTriggerEnter(Collider other)
		{
			Unit unit = other.GetComponent<Unit>();
			if (_validAttacks.ContainsKey((unit.unitType, attackType)))
			{
				_validAttacks[(unit.unitType, attackType)].Invoke(this, unit);
			}
		}
	
		public void TankAttack(Unit self, Unit other) { ... }
		public void MissleAttack(Unit self, Unit other) { ... }
		public void TorpedoAttack(Unit self, Unit other) { ... }
		public void IcbmAttack(Unit self, Unit other) { ... }
	}
