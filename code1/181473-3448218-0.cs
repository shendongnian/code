    public static class ConverterFactory {
        public static CreateConverter1() { 
           return new Converter(new Reader1());
        }
        public static CreateConverter2() {
           return new Converter(new Reader2());
        }
    }
    
    ...
    Converter x = ConverterFactory.CreateConverter1();
