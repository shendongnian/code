	public abstract class Tile
	{
		protected readonly IDice Dice;
		protected readonly ILogger Logger;
		protected Tile(ILogger logger, IDice dice)
		{
			this.Logger = logger;
			this.Dice = dice;
		}
		public abstract int Location
		{
			get;
		}
		public abstract void LandedOnTile(IPlayer player);
	}
	public class JailTile : Tile
	{
		public JailTile(ILogger logger, IDice dice): base (logger, dice)
		{
		}
		public override int Location => 3;
		public override void LandedOnTile(IPlayer player)
		{
			if (player.InJail)
			{
				this.GetOutOfJail(player);
			}
			else
			{
				this.Logger.LogMessage($"{player.Name} is just visiting jail");
			}
		}
		private void GetOutOfJail(IPlayer player)
		{
			int roll = this.Dice.Roll();
			int turnsInJail = player.TimeInJail;
			if (turnsInJail == 3)
			{
				player.InJail = false;
				this.Logger.LogMessage($"{player.Name} has spent 3 turns in jail and is now out");
				player.TimeInJail = 0;
			}
			else if (turnsInJail < 3 && roll > 2)
			{
				player.InJail = false;
				this.Logger.LogMessage($"{player.Name} has rolled a 3 and it out of jail");
				player.TimeInJail = 0;
			}
			else
			{
				this.Logger.LogMessage($"{player.Name} has rolled a lower than a 3 and is in jail for another turn");
				player.TimeInJail++;
			}
		}
	}
