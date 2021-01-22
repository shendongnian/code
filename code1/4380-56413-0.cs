    public interface Result {
        String name();
        String toString();
    }
    public enum StandardResults implements Result {
        TRUE, FALSE
    }
    public enum WTFResults implements Result {
        FILE_NOT_FOUND
    }
