    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using SubSonic.Repository;
    
    namespace SubsonicOneToManyRelationshipChildObjects
    {
    	public static class Program
    	{
    		private static readonly SimpleRepository Repository;
    
    		static Program()
    		{
    			try
    			{
    				Repository = new SimpleRepository("SubsonicOneToManyRelationshipChildObjects.Properties.Settings.StackOverflow", SimpleRepositoryOptions.RunMigrations);
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine(ex);
    				Console.ReadLine();
    			}
    		}
    
    		public class Article
    		{
    
    			public int Id { get; set; }
    			public string Name { get; set; }
    
    			private ArticleCategory category;
    			public ArticleCategory Category
    			{
    				get { return category ?? (category = Repository.Single<ArticleCategory>(single => single.Id == ArticleCategoryId)); }
    			}
    
    			public int ArticleCategoryId { get; set; }
    
    			private List<ArticleComment> comments;
    			public List<ArticleComment> Comments
    			{
    				get { return comments ?? (comments = Repository.Find<ArticleComment>(comment => comment.ArticleId == Id).ToList()); }
    			}
    		}
    
    		public class ArticleCategory
    		{
    			public int Id { get; set; }
    			public string Name { get; set; }
    		}
    
    		public class ArticleComment
    		{
    			public int Id { get; set; }
    			public string Name { get; set; }
    
    			public string Body { get; set; }
    
    			public int ArticleId { get; set; }
    		}
    
    		public static void Main(string[] args)
    		{
    			try
    			{
    				// generate database schema
    				Repository.Single<ArticleCategory>(entity => entity.Name == "Schema Update");
    				Repository.Single<ArticleComment>(entity => entity.Name == "Schema Update");
    				Repository.Single<Article>(entity => entity.Name == "Schema Update");
    
    				var category1 = new ArticleCategory { Name = "ArticleCategory 1"};
    				var category2 = new ArticleCategory { Name = "ArticleCategory 2"};
    				var category3 = new ArticleCategory { Name = "ArticleCategory 3"};
    
    				// clear/populate the database
    				Repository.DeleteMany((ArticleCategory entity) => true);
    				var cat1Id = Convert.ToInt32(Repository.Add(category1));
    				var cat2Id = Convert.ToInt32(Repository.Add(category2));
    				var cat3Id = Convert.ToInt32(Repository.Add(category3));
    
    				Repository.DeleteMany((Article entity) => true);
    				var article1 = new Article { Name = "Article 1", ArticleCategoryId = cat1Id };
    				var article2 = new Article { Name = "Article 2", ArticleCategoryId = cat2Id };
    				var article3 = new Article { Name = "Article 3", ArticleCategoryId = cat3Id };
    
    				var art1Id = Convert.ToInt32(Repository.Add(article1));
    				var art2Id = Convert.ToInt32(Repository.Add(article2));
    				var art3Id = Convert.ToInt32(Repository.Add(article3));
    
    				Repository.DeleteMany((ArticleComment entity) => true);
    				var comment1 = new ArticleComment { Body = "This is comment 1", Name = "Comment1", ArticleId = art1Id };
    				var comment2 = new ArticleComment { Body = "This is comment 2", Name = "Comment2", ArticleId = art1Id };
    				var comment3 = new ArticleComment { Body = "This is comment 3", Name = "Comment3", ArticleId = art1Id };
    				var comment4 = new ArticleComment { Body = "This is comment 4", Name = "Comment4", ArticleId = art2Id };
    				var comment5 = new ArticleComment { Body = "This is comment 5", Name = "Comment5", ArticleId = art2Id };
    				var comment6 = new ArticleComment { Body = "This is comment 6", Name = "Comment6", ArticleId = art2Id };
    				var comment7 = new ArticleComment { Body = "This is comment 7", Name = "Comment7", ArticleId = art3Id };
    				var comment8 = new ArticleComment { Body = "This is comment 8", Name = "Comment8", ArticleId = art3Id };
    				var comment9 = new ArticleComment { Body = "This is comment 9", Name = "Comment9", ArticleId = art3Id };
    				Repository.Add(comment1);
    				Repository.Add(comment2);
    				Repository.Add(comment3);
    				Repository.Add(comment4);
    				Repository.Add(comment5);
    				Repository.Add(comment6);
    				Repository.Add(comment7);
    				Repository.Add(comment8);
    				Repository.Add(comment9);
    
    				// verify the database generation
    				Debug.Assert(Repository.All<Article>().Count() == 3);
    				Debug.Assert(Repository.All<ArticleCategory>().Count() == 3);
    				Debug.Assert(Repository.All<ArticleComment>().Count() == 9);
    
    				// fetch a master list of articles from the database
    				var articles = 
    					(from article in Repository.All<Article>() 
    					join category in Repository.All<ArticleCategory>() 
    						on article.ArticleCategoryId equals category.Id 
    					join comment in Repository.All<ArticleComment>() 
    						on article.Id equals comment.ArticleId 
    					select article)
    					.Distinct()
    					.ToList();
    
    				foreach (var article in articles)
    				{
    					Console.WriteLine(article.Name  + " ID " + article.Id);
    					Console.WriteLine("\t" + article.Category.Name + " ID " + article.Category.Id);
    
    					foreach (var articleComment in article.Comments)
    					{
    						Console.WriteLine("\t\t" + articleComment.Name + " ID " + articleComment.Id);
    						Console.WriteLine("\t\t\t" + articleComment.Body);
    					}
    				}
    
    				// OUTPUT (ID will vary as autoincrement SQL index
    
    				//Article 1 ID 28
    				//        ArticleCategory 1 ID 41
    				//                Comment1 ID 100
    				//                        This is comment 1
    				//                Comment2 ID 101
    				//                        This is comment 2
    				//                Comment3 ID 102
    				//                        This is comment 3
    				//Article 2 ID 29
    				//        ArticleCategory 2 ID 42
    				//                Comment4 ID 103
    				//                        This is comment 4
    				//                Comment5 ID 104
    				//                        This is comment 5
    				//                Comment6 ID 105
    				//                        This is comment 6
    				//Article 3 ID 30
    				//        ArticleCategory 3 ID 43
    				//                Comment7 ID 106
    				//                        This is comment 7
    				//                Comment8 ID 107
    				//                        This is comment 8
    				//                Comment9 ID 108
    				//                        This is comment 9			
    
    				Console.ReadLine();
    
    				// BETTER WAY (imho)...(joins aren't needed thus freeing up SQL overhead)
    
    				// fetch a master list of articles from the database
    				articles = Repository.All<Article>().ToList();
    
    				foreach (var article in articles)
    				{
    					Console.WriteLine(article.Name + " ID " + article.Id);
    					Console.WriteLine("\t" + article.Category.Name + " ID " + article.Category.Id);
    
    					foreach (var articleComment in article.Comments)
    					{
    						Console.WriteLine("\t\t" + articleComment.Name + " ID " + articleComment.Id);
    						Console.WriteLine("\t\t\t" + articleComment.Body);
    					}
    				}
    
    				Console.ReadLine();
    
    				// OUTPUT should be identicle
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine(ex);
    				Console.ReadLine();
    			}
    		}
    	}
    }
