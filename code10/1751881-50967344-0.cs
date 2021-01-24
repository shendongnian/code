    using log4net;
    using System;
    using System.Reflection;
    
    namespace Common
    {
        /// <summary>
        /// Logger class holds Log4Net implementation
        /// </summary>
        public class Logger 
        {
            #region Private Members
    
            /// <summary>
            /// ILog specific to Log4Net
            /// </summary>
            private readonly ILog logger;
    
            #endregion
    
            #region Constructor
    
            /// <summary>
            /// Initializes a new instance of the <see cref="Logger"/> class.
            /// Used to initialize logger
            /// </summary>
            public Logger()
            {
                logger = log4net.LogManager.GetLogger(nameof(Logger));
            }
    
            #endregion
    
            #region Public Methods
    
            /// <summary>
            /// Logs a message object with Error Level.
            /// </summary>
            /// <param name="message">The message string to log.</param>
            /// <param name="loggerName">Name of the logger</param>
            public void Error(object message, string loggerName = null)
            {
                if (!string.IsNullOrEmpty(loggerName))
                {
                    log4net.LogManager.GetLogger(loggerName).Error(message);
                }
                else
                {
                    logger.Error(message);
                }
            }
    
            /// <summary>
            /// Logs a message object with Error Level.
            /// </summary>
            /// <param name="message">The message object to log.</param>
            /// <param name="exception">The exception to log.</param>
            /// <param name="loggerName">Name of the logger</param>
            public void Error(object message, Exception exception, string loggerName = null)
            {
                if (!string.IsNullOrEmpty(loggerName))
                {
                    log4net.LogManager.GetLogger(loggerName).Error(message, exception);
                }
                else
                {
                    logger.Error(message, exception);
                }
            }
    
            /// <summary>
            /// Logs a message object with Info Level.
            /// </summary>
            /// <param name="message">The message object to log.</param>
            /// <param name="loggerName">Name of the logger</param>
            public void Info(string message, string loggerName = null)
            {
                if (!string.IsNullOrEmpty(loggerName))
                {
                    log4net.LogManager.GetLogger(loggerName).Info(message);
                }
                else
                {
                    logger.Info(message);
                }
            }
    
            /// <summary>
            /// Logs a message object with Info Level.
            /// </summary>
            /// <param name="message">The message object to log.</param>
            /// <param name="loggerName">Name of the logger</param>
            public void Info(object message, string loggerName = null)
            {
    
                if (!string.IsNullOrEmpty(loggerName))
                {
                    log4net.LogManager.GetLogger(loggerName).Info(message);
                }
                else
                {
                    logger.Info(message);
                }
            }
            /// <summary>
            /// Logs a message object with Info Level.
            /// </summary>
            /// <param name="message">The message object to log.</param>
            /// <param name="exception">The exception to log.</param>
            /// <param name="loggerName">Name of the logger</param>
            public void Info(string message, Exception exception, string loggerName = null)
            {
                if (!string.IsNullOrEmpty(loggerName))
                {
                    log4net.LogManager.GetLogger(loggerName).Info(message, exception);
                }
                else
                {
                    logger.Info(message, exception);
                }
            }
    
            /// <summary>
            /// Logs a message object with Debug Level.
            /// </summary>
            /// <param name="message">The message object to log.</param>
            /// <param name="loggerName">Name of the logger</param>
            public void Debug(string message, string loggerName = null)
            {
                if (!string.IsNullOrEmpty(loggerName))
                {
                    log4net.LogManager.GetLogger(loggerName).Debug(message);
                }
                else
                {
                    logger.Debug(message);
                }
            }
    
            /// <summary>
            /// Logs a message object with Debug Level.
            /// </summary>
            /// <param name="message">The message object to log.</param>
            /// <param name="exception">The exception to log.</param>
            /// <param name="loggerName">Name of the logger</param>
            public void Debug(string message, Exception exception, string loggerName = null)
            {
                if (!string.IsNullOrEmpty(loggerName))
                {
                    log4net.LogManager.GetLogger(loggerName).Debug(message, exception);
                }
                else
                {
                    logger.Debug(message, exception);
                }
            }
    
            #endregion
        }
    }
