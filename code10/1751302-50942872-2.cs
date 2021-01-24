	var validAttacks = new (UnitType, AttackType)[]
	{
		(UnitType.Air, AttackType.Air),
		(UnitType.Air, AttackType.Ground),
		(UnitType.Ground, AttackType.Ground),
		(UnitType.Water, AttackType.Water),
		(UnitType.Water, AttackType.Air),
	};
