    public class HtmlSanitizerFactory {
          private static final HtmlSanitizerFactory instance = new HtmlSanitizerFactory();
          
          private HtmlSanitizerFactory() {}
          
          public static HtmlSanitizerFactory get() { return instance;}
          public HtmlSanitizer getSanitizer() {
              return new MyKickassHtmlSanitizer();
          }
    } 
