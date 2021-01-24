    public class Singer {
		public int Id { get; set; }
		public string Name { get; set; }
		public SingerType SingerType { get; set; }
		public virtual Quartet Quartet { get; set; }
	}
	public class Quartet {
		public int Id { get; set; }
		public virtual List<Singer> Singers { get; set; }
		public string Name { get; set; }
		public Singer GetByType(SingerType type) {
			return Singers.FirstOrDefault(e => e.SingerType == type);
		}
		public void AddSinger(Singer singer) {
			if (Singers.Any(e => e.SingerType == singer.SingerType)) {
				throw new Exception($"You cannot add additional-{singer.SingerType} to quartet->{this.Name}");
			}
			if (Singers.Count > 3) {
				throw new Exception($"You cannot add additional singer->{singer.Name} to quartet->{this.Name} cause quartet already more than 3 members");
			}
			Singers.Add(singer);
		}
	}
	public class MyFancyClass {
		private readonly Context _context;
		public MyFancyClass(Context context) {
			_context = context;
		}
		public Quartet DoWhatEverWithQartet(string name) {
			var myQuartet = _context.Quartets.FirstOrDefault(e => e.Name == name);
			foreach (var singer in myQuartet.Singers) {
				// Do whatever logic with singer
			}
			return myQuartet;
		}
		public void DoWhatEverLogicWithBassOfQuartet(string name) {
			var myQuartet = _context.Quartets.FirstOrDefault(e => e.Name == name);
			var bass = myQuartet.GetByType(SingerType.Bass);
			// Do whatever logic with bass
		}
	}
	public enum SingerType {
		Unknown = 0,
		Bass = 1,
		Bariton = 2,
		Lead = 3,
		Tenor = 4,
		Bullshit = 5,
		WhatEver = 6,
	}
	public class Context : DbContext {
		public IDbSet<Singer> Singers { get; set; }
		public IDbSet<Quartet> Quartets { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Configurations.Add(new QuartetConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}
	public class QuartetConfiguration : EntityTypeConfiguration<Quartet> {
		public QuartetConfiguration() {
			HasKey(e => e.Id);
			HasMany(e => e.Singers).WithRequired(e => e.Quartet).WillCascadeOnDelete(false);
		}
	}
