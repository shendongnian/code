    using System;
    using System.Threading;
    
    /// <summary>
    /// Classe utilitária para suporte a resiliência
    /// </summary>
    public sealed class Resiliency
    {
    	/// <summary>
    	/// Define o valor padrão de número de tentativas
    	/// </summary>
    	public static int DefaultRetryCount { get; set; }
    
    	/// <summary>
    	/// Define o valor padrão (em segundos) de tempo de espera entre tentativas
    	/// </summary>
    	public static int DefaultRetryTimeout { get; set; }
    
    	/// <summary>
    	/// Inicia a parte estática da resiliência, com os valores padrões
    	/// </summary>
    	static Resiliency()
    	{
    		DefaultRetryCount = 3;
    		DefaultRetryTimeout = 0;
    	}
    
    	/// <summary>
    	/// Executa uma <see cref="Action"/> e tenta novamente DefaultRetryCount vezes  quando for disparada qualquer <see cref="Exception"/> 
    	/// </summary>
    	/// <param name="action">Ação a ser realizada</param>
    	/// <remarks>Executa uma vez e realiza outras DefaultRetryCount tentativas em caso de exceção. Não aguarda para realizar novas tentativa.</remarks>
    	public static void Try(Action action)
    	{
    		Try<Exception>(action, DefaultRetryCount, TimeSpan.FromMilliseconds(DefaultRetryTimeout), null);
    	}
    
    	/// <summary>
    	/// Executa uma <see cref="Action"/> e tenta novamente determinado número de vezes quando for disparada qualquer <see cref="Exception"/> 
    	/// </summary>
    	/// <param name="action">Ação a ser realizada</param>
    	/// <param name="retryCount">Número de novas tentativas a serem realizadas</param>
    	/// <param name="retryTimeout">Tempo de espera antes de cada nova tentativa</param>
    	public static void Try(Action action, int retryCount, TimeSpan retryTimeout)
    	{
    		Try<Exception>(action, retryCount, retryTimeout, null);
    	}
    
    	/// <summary>
    	/// Executa uma <see cref="Action"/> e tenta novamente determinado número de vezes quando for disparada qualquer <see cref="Exception"/> 
    	/// </summary>
    	/// <param name="action">Ação a ser realizada</param>
    	/// <param name="retryCount">Número de novas tentativas a serem realizadas</param>
    	/// <param name="retryTimeout">Tempo de espera antes de cada nova tentativa</param>
    	/// <param name="tryHandler">Permitindo manipular os critérios para realizar as tentativas</param>
    	public static void Try(Action action, int retryCount, TimeSpan retryTimeout, Action<ResiliencyTryHandler<Exception>> tryHandler)
    	{
    		Try<Exception>(action, retryCount, retryTimeout, tryHandler);
    	}
    
        /// <summary>
        /// Executa uma <see cref="Action"/> e tenta novamente por até DefaultRetryCount vezes quando for disparada qualquer <see cref="Exception"/> 
        /// </summary>
        /// <param name="action">Ação a ser realizada</param>
        /// <param name="tryHandler">Permitindo manipular os critérios para realizar as tentativas</param>
        /// <remarks>Executa uma vez e realiza outras DefaultRetryCount tentativas em caso de exceção. Aguarda DefaultRetryTimeout segundos antes de realizar nova tentativa.</remarks>
        public static void Try(Action action, Action<ResiliencyTryHandler<Exception>> tryHandler)
    	{
    		Try<Exception>(action, DefaultRetryCount, TimeSpan.FromSeconds(DefaultRetryTimeout), null);
    	}
    
        /// <summary>
        /// Executa uma <see cref="Action"/> e tenta novamente determinado número de vezes quando for disparada qualquer <see cref="TException"/> 
        /// </summary>
        /// <param name="action">Ação a ser realizada</param>
        /// <remarks>Executa uma vez e realiza outras DefaultRetryCount tentativas em caso de exceção. Aguarda DefaultRetryTimeout segundos antes de realizar nova tentativa.</remarks>
        public static void Try<TException>(Action action) where TException : Exception
    	{
    		Try<TException>(action, DefaultRetryCount, TimeSpan.FromSeconds(DefaultRetryTimeout), null);
    	}
    
        /// <summary>
        /// Executa uma <see cref="Action"/> e tenta novamente determinado número de vezes quando for disparada qualquer <see cref="TException"/> 
        /// </summary>
        /// <param name="action">Ação a ser realizada</param>
        /// <param name="retryCount"></param>
        public static void Try<TException>(Action action, int retryCount) where TException : Exception
    	{
    		Try<TException>(action, retryCount, TimeSpan.FromSeconds(DefaultRetryTimeout), null);
    	}
    
        /// <summary>
        /// Executa uma <see cref="Action"/> e tenta novamente determinado número de vezes quando for disparada qualquer <see cref="Exception"/> 
        /// </summary>
        /// <param name="action">Ação a ser realizada</param>
        /// <param name="retryCount"></param>
        /// <param name="retryTimeout"></param>
        public static void Try<TException>(Action action, int retryCount, TimeSpan retryTimeout) where TException : Exception
    	{
    		Try<TException>(action, retryCount, retryTimeout, null);
    	}
    
        /// <summary>
        /// Executa uma <see cref="Action"/> e tenta novamente determinado número de vezes quando for disparada qualquer <see cref="Exception"/> 
        /// </summary>
        /// <param name="action">Ação a ser realizada</param>
        /// <param name="tryHandler">Permitindo manipular os critérios para realizar as tentativas</param>
        /// <remarks>Executa uma vez e realiza outras DefaultRetryCount tentativas em caso de exceção. Aguarda DefaultRetryTimeout segundos antes de realizar nova tentativa.</remarks>
        public static void Try<TException>(Action action, Action<ResiliencyTryHandler<TException>> tryHandler) where TException : Exception
    	{
    		Try(action, DefaultRetryCount, TimeSpan.FromSeconds(DefaultRetryTimeout), tryHandler);
    	}
    
    	/// <summary>
    	/// Executa uma <see cref="Action"/> e tenta novamente determinado número de vezes quando for disparada uma <see cref="Exception"/> definida no tipo genérico
    	/// </summary>
    	/// <param name="action">Ação a ser realizada</param>
    	/// <param name="retryCount">Número de novas tentativas a serem realizadas</param>
    	/// <param name="retryTimeout">Tempo de espera antes de cada nova tentativa</param>
    	/// <param name="tryHandler">Permitindo manipular os critérios para realizar as tentativas</param>
    	/// <remarks>Construído a partir de várias ideias no post <seealso cref="http://stackoverflow.com/questions/156DefaultRetryCount191/c-sharp-cleanest-way-to-write-retry-logic"/></remarks>
    	public static void Try<TException>(Action action, int retryCount, TimeSpan retryTimeout, Action<ResiliencyTryHandler<TException>> tryHandler) where TException : Exception
    	{
    		if (action == null)
    			throw new ArgumentNullException(nameof(action));
    
    		while (retryCount-- > 0)
    		{
    			try
    			{
    				action();
    				return;
    			}
    			catch (TException ex)
    			{
    				//Executa o manipulador de exception
    				if (tryHandler != null)
    				{
    					var callback = new ResiliencyTryHandler<TException>(ex, retryCount);
    					tryHandler(callback);
    					//A propriedade que aborta pode ser alterada pelo cliente
    					if (callback.AbortRetry)
    						throw;
    				}
    
    				//Aguarda o tempo especificado antes de tentar novamente
    				Thread.Sleep(retryTimeout);
    			}
    		}
    
    		//Na última tentativa, qualquer exception será lançada de volta ao chamador
    		action();
    	}
    
    }
   
    /// <summary>
    /// Permite manipular o evento de cada tentativa da classe de <see cref="Resiliency"/>
    /// </summary>
    public class ResiliencyTryHandler<TException> where TException : Exception
    {
    	#region Properties
    
    	/// <summary>
    	/// Opção para abortar o ciclo de tentativas
    	/// </summary>
    	public bool AbortRetry { get; set; }
    
    	/// <summary>
    	/// <see cref="Exception"/> a ser tratada
    	/// </summary>
    	public TException Exception { get; private set; }
    
    	/// <summary>
    	/// Identifca o número da tentativa atual
    	/// </summary>
    	public int CurrentTry { get; private set; }
    
    	#endregion
    
    	#region Constructors
    
    	/// <summary>
    	/// Instancia um manipulador de tentativa. É utilizado internamente
    	/// por <see cref="Resiliency"/> para permitir que o cliente altere o
    	/// comportamento do ciclo de tentativas
    	/// </summary>
    	public ResiliencyTryHandler(TException exception, int currentTry)
    	{
    		Exception = exception;
    		CurrentTry = currentTry;
    	}
    
    	#endregion
    
    }
