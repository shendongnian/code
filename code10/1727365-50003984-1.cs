    namespace jurnal1 {
    		using System;
    		using System.Data.Entity;
    		using System.Data.Entity.Infrastructure;
            using System.ComponentModel.DataAnnotations.Schema;
    
    		public partial class DiaryEntities : DbContext {
    
    			public DiaryEntities ( )
    				: base ( "name=DiaryEntities" ) {
    			}
    
    			protected override void OnModelCreating ( DbModelBuilder modelBuilder ) {
    				throw new UnintentionalCodeFirstException ( );
    			}
    			public DbSet<Entries> Diary { get; set; }
    
    		}
    
    		[Table("entries")]
    		public class Entries {
    			public string Title { get; set; }
    			public DateTime Date { get; set; }
    			public string Content { get; set; }
    		}
    	}
    }
