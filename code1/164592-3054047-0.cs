    int i, iMax;
    i = iMax = lines.length;
    sb.Append(">>> "); // ACT ON THE FIRST ITEM
    while(i--) {
      sb.Append("[" + lines[length - i] + "]"); // ACT ON ITEM
      if(i) {
        sb.Append(", ");  // ACT ON NOT THE LAST ITEM
      } else {
        sb.Append(" <<<");  // ACT ON LAST ITEM
      }
    }
