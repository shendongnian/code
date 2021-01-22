    [Serializable]
	class Spell
	{
		string Name { get; set; }
		Dictionary<PowerSource, double> PowerCost { get; set; }
		Dictionary<PowerSource, TimeSpan> CoolDown { get; set; }
		ActionProperty[] Properties { get; set; }
		ActionEffect Apply(Wizzard entity)
		{
			// evaluate
			var effect = new ActionEffect();
			foreach (var property in Properties)
			{
				entity.Defend(property,effect);
			}
			// then apply
			entity.Apply(effect);
			// return the spell total effects for pretty printing
			return effect;
		}
	}
	internal class ActionEffect
	{
		public Dictionary<DamageKind,double> DamageByKind{ get; set;}		
		public Dictionary<string,TimeSpan> NeutralizedActions{ get; set;}		
		public Dictionary<string,double> EquipmentDamage{ get; set;}
		public Location EntityLocation{ get; set;} // resulting entity location
		public Location ActionLocation{ get; set;} // source action location (could be deflected for example)
	}
	[Serializable]
	class ActionProperty
	{
		public DamageKind DamageKind { get;  set; }
		public double? DamageValue { get; set;}
		public int? Range{ get; set;}
		public TimeSpan? duration { get; set; }
		public string Effect{ get; set}
	}
	[Serializable]
	class Wizzard
	{
		public virtual void Defend(ActionProperty property,ActionEffect totalEffect)
		{
			// no defence	
		}
		public void Apply(ActionEffect effect)
		{
			// self damage
			foreach (var byKind in effect.DamageByKind)
			{
				this.hp -= byKind.Value;
			}
			// let's say we can't move for X seconds
			foreach (var neutralized in effect.NeutralizedActions)
			{
				Actions[neutralized.Key].NextAvailable += neutralized.Value;
			}
			// armor damage?
			foreach (var equipmentDamage in effect.EquipmentDamage)
			{
				equipment[equipmentDamage.Key].Damage += equipmentDamage.Value;
			}
		}
	}
	
	[Serializable]
	class RinceWind:Wizzard
	{
		public override void Defend(ActionProperty property, ActionEffect totalEffect)
		{
			// we have resist magic !
			if(property.DamageKind==DamageKind.Magic)
			{
				log("resited magic!");
				double dmg = property.DamageValue - MagicResistance;
				ActionProperty resistedProperty=new ActionProperty(property);
				resistedProperty.DamageValue = Math.Min(0,dmg);                
				return;
			}			
			base.Receive(property, totalEffect);
		}
	}
