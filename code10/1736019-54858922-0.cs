    private ListNode AddTwoNumbersHelper(ListNode l1, ListNode l2) {
        ListNode result = null;
        ListNode tail = null;
        int carry = 0;
        while ((l1 != null) || (l2 != null) || (carry != 0)) {
            int sum = carry;
            if (l1 != null) {
                sum += l1.val;
                l1 = l1.next;
            }
            if (l2 != null) {
                sum += l2.val;
                l2 = l2.next;
            }
            carry = sum/10;
            sum %= 10;
            if (result == null) { // first time
                result = new ListNode(sum);
                tail = result;
            } else {
                tail.next = new ListNode(sum);
                tail = tail.next;
            }
        }
        return result;
    }
