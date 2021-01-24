    class Data {
    }
    
    class ExtendedData : Data {
    }
    
    static class Pipeline {
        public static ExtendedData A<T>(this T value) where T : Data {
            if (value is ExtendedData extended) {
                return extended;
            }
            else {
                return new ExtendedData():
            }
        }
    
        public static T B<T>(this T value) where T : Data {
            return value;
        }
    
        public static ExtendedData C(this ExtendedData value) {
            return value;
        }
    }
