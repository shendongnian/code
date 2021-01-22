    StringBuilder sb = new StringBuilder();
    using (StringWriter sw = new StringWriter()) {
        using (IndentedTextWriter itw = new IndentedTextWriter(sw)) {
            ... 
        }
    }
