AccessibilityDelegateCompat myAccessibilityDelegate = new AccessibilityDelegateCompat() {
            @Override
            public void onInitializeAccessibilityNodeInfo(View view, AccessibilityNodeInfoCompat info) {
                super.onInitializeAccessibilityNodeInfo(view, info);
                if (role != null) {
                    CharSequence role;
                    switch (role) {
                        case Button:
                            roleDescription = "button"
                            break;
                        case Link:
                            roleDescription = "link"
                            break;
                    info.setRoleDescription(roleDescription);
                }
            }
        };
