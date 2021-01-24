    public class MySqlFilmRepository : IFilmRepository
    {
        readonly string _connectionString { get; set; }
    	
        public FilmRepsitory(string connectionString)
    	{
    	    _connectionString = connectionString;
    	}
    	
    	public List<Film> SearchFilmsByTitle(string title)
    	{
    	    using (var connection = new MySqlConnection(_connectionString)
    		{
    		    List<Film> films = connection.Query<Film>("SELECT title, description, release_year, rental_rate, length, rating FROM film WHERE title LIKE @Title", new { Title = title }).AsList();
    			
    			return films;
    		}
    	}
    	
    	public List<Actor> GetActorsForFilm(string filmTitle)
    	{
    	    using (var connection = new MySqlConnection(_connectionString)
    		{
    	        List<Actor> actors = connection.Query<Actor>("SELECT first_name, last_name FROM actor INNER JOIN film_actor ON actor.actor_id = film_actor.actor_id INNER JOIN film ON film.film_id = film_actor.film_id WHERE film.title LIKE @FilmTitle", new { FilmTitle = filmTitle }).AsList();
    			
    			return actors;
    		}
    	}
    }
    
    public interface IFilmRepository
    {
        List<Film> SearchFilmsByTitle(string title);
    	
    	List<Actor> GetActorsForFilm(string filmTitle);
    }
